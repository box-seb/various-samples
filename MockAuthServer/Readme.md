# Mock Nexus Auth Server

It is an authorization server used to issue NEXT tokens for local Public API Adapter development.
The token is then used by Public API Adapter as subject token for [token exchange](https://datatracker.ietf.org/doc/html/rfc8693).

## Installation
- Create entry in hosts file
```
127.0.0.1   auth-server-name.test
```

- Run certificate creation via PowerShell:
```
.\create-cert-for-local-dev.ps1
```

## Build the image
Run the PowerShell script:
```
.\docker-image-build.ps1
```

## Run the docker
The app runs as docker and uses installed certificate. Run with PowerShell:

```
.\docker-container-start.ps1
```

## Get the token
Make a request with following parameters:
- Token Url `https://auth-server-name.test/connect/token`
- Client id `nexus`
- Client secret `secret`
- `grant_type` is `client_credentials`
- Scopes can be left empty. However, following scopes are supported: `payment:read` `community:read` `community:manage`
 