
# MailSenderServiceApp
This project will serve as an example of an app that can send mails.

## Install Dependencies:
Here below are the dependencies you need to get started before you run the project.

```sh
dotnet add package MailKit
dotnet add package MimeKit
```

## Build and run the app

```sh
dotnet build
dotnet run
```

## Important:
Before you run the app you must replace the config values set in the [appsettings.json] file.

```sh
"MailSettings": {
    "UserName": "<username_here>",
    "Password": "<password_here>",
    "DisplayName": "<displayname_here>",
    "Host": "<hostname_here>",
    "Port": "<portnumber_here>"
  }
```
