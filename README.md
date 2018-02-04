# DNN Powershell ###

A DNN PowerShell module that uses the WebAPI endpoint of DNN 9.2's new Prompt PersonaBar extension

### Summary ###

DNN Platform version 9.2 introduced a new PersonaBar extension called Prompt. This opens up a command shell like window
over the top of the current page and allows you to run commands to perform certain administrative tasks (add/remove pages, 
users etc). Because this is done by sending commands from the browser to the server using a WebAPI endpoint, it opens
up the ability to run commands from other programs than a web browser. This is leveraged with this component. DNN Powershell
acts as a Powershell "module" and offers the same commands that ship with the default Prompt extension of DNN inside
your Powershell environment. So now you can type "List-Users" from Powershell and expect the same result as if you were
in Prompt on DNN.

### Installation ###

The code compiles to a single Connect.DNN.Powershell.dll. Drop this somewhere inside your WindowsPowerShell folder and 
register the module using import-module:

```
import-module Path\To\Connect.DNN.Powershell.dll -DisableNameChecking
```

On the DNN side you will need to ensure you have [JWT enabled](http://www.dnnsoftware.com/docs/developers/jwt/index.html). 
Note that by default it is only permitted over https and we encourage you to keep it that way.

### Usage ###

At any given time there can be only one default site active in your Powershell session. This means that when you type
*list-users* that the component knows where to get those users. There are two mechanisms by which we set the current
site: by switching to it from a stored list of sites through a _key_ of your choosing, or by connecting to it explicitly.
The list of stored site uses EncryptedString to store the site's keys for security reasons. Using the "live" method means
you need to log in every single time you start up Powershell. It will depend on your situation which approach is the best
for you.

#### List of sites ####

Use *add-site* to add a site to this list. Syntax:

```
add-site -key mysite -url http://www.myserver.com -username host -password mypassword
```

This will add the DNN site at the specified url and store it using the key _mysite_. You can now switch to this or run
any command in any context and use "-key mysite" to point to this site. Switch the current context using:

```
use-site -key mysite
```

and the current context will use this site. This allows you to run commands without specifying the site.

#### Using a site without storing it locally ####

You can switch to a site without using local storage through

```
use-site -url http://www.myserver.com -username host -password mypassword
```

As soon as you close Powershell that connection will be lost.

### Limitations ###

You must use superuser credentials for DNN to use this. This is because the Prompt WebAPI endpoint currently requires it. 
We expect that in some point in the future this may change but for now you need to be superuser.

