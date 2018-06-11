# IdentityServer4.Contrib.MongoDB

[![Build Status](https://travis-ci.org/christophla/Envoice.MongoIdentityServer.svg?branch=master)](https://travis-ci.org/christophla/Envoice.MongoIdentityServer)

MongoDB persistence layer for IdentityServer4 based on the Official [EntityFramework](https://github.com/IdentityServer/IdentityServer4.EntityFramework) persistence layer.

### Envoice 

# MongoIdentityServer [![Build status](https://ci.appveyor.com/api/projects/status/09c4fnv2ov54vpwm?svg=true)](https://ci.appveyor.com/project/christophla/mongo.identityserver)

MongoDB persistence layer for IdentityServer4 based on the Official [EntityFramework](https://github.com/IdentityServer/IdentityServer4.EntityFramework) persistence layer.

Supports virtual collections from [MongoRepository](https://bitbucket.org/envoice-tech/mongo.identityserver)

## Supported Platforms
* .NET 2.0

## Installation

https://www.myget.org/feed/envoice/package/nuget/Envoice.MongoIdentityServer

Add dependency to you project.json:

``` bash

dotnet add package Envoice.MongoIdentityServer --version 1.0.0 --source https://www.myget.org/F/envoice/api/v3/index.json
```

### Virtual Collections

Virtual collections allow multiple entity types to be stored in a single collection.

#### Connection String

Connection string options can be used to configure the repositories. All connection string options override code-based options, e.g. *MongoRepositoryConfig*.

```
mongodb://{host}:{port}/?virtual=true&virtualCollection=Entities&virtualCollectionGlobal=true
```

- *virtual* (boolean) : Enables virtual collections. Default = false. 
- *virtualCollection* (string) : Default virtual collection for all unmapped entities.
- *virtualCollectionGlobal* (boolean) : Overrides all entities to use the *virtualCollection* regardless of mapping configuration.

#### ASPNET Service (TODO)

The repositories can be configured to use virtual collections in ASPNET applications via the UseMongoRepository method.

``` C#
services.UseMongoRepository(config => {

    config.VirtualCollectionDefault = "Entities";
    config.VirtualCollectionEnabled = true;
    config.VirtualCollectionForceGlobal = false;

});
```

#### Attributes

``` C#
  [VirtualCollectionName("Entities")]
  public class Product {
    ...
  }
```
