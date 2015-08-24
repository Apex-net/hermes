hermes
======

Dispatch Notification Suite


Server
------


### How to Install

0. Go to [releases](https://github.com/Apex-net/hermes/releases)
0. Download latest version of `dispatch/api/v*.7z`
0. Extract contents of `DispatchApi-v*.7z`
0. Convert extracted folder to Application in IIS


### Configuration

0. Open `Web.config` file inside IIS application folder you previously created using a plain text editor
0. Configure [mandatory settings](#Mandatory-Settings)
0. Configure [optional settings](#Optional-Settings)

#### Mandatory Settings

The only mandatory configuration is setting available storage option via `JobStorageName` in application settings:

```xml
  <applicationSettings>
    <Apexnet.Dispatch.Api.Properties.Settings>
      <setting name="JobStorageName" serializeAs="String">
        <value>hangfire-redis</value>
      </setting>
    </Apexnet.Dispatch.Api.Properties.Settings>
  </applicationSettings>
```

Available values for `JobStorageName` are: `hangfire-redis` or `hangfire-memory`. As default `hangfire-redis` is selected.

:warning: `hangfire-redis` storage option requires additional configurations. See [redis storage](#Redis-Storage) section.

#### Optional Settings

##### Storage Options

###### Redis Storage

`HangfireStorage` must be configured correctly:

```xml
  <HangfireStorage xmlns="urn:Apexnet.JobQueue.Configuration">
    <redisStorage connectionString="{HANGFIRE_STORAGE_REDIS_CONNECTION}"/>
  </HangfireStorage>
```

###### Memory Storage

No configuration is necessary.


Client SDK
----------

### C#/.NET

0. [Install NuGet](https://docs.nuget.org/consume/installing-nuget)
0. Install [Apexnet.Dispatch.Api.Client](http://www.nuget.org/packages/Apexnet.Dispatch.Api.Client/) via NuGet

#### Usage

_:construction_worker: This section is currently missing_
