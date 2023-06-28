# MVC Test

Testing with various things like MVC, Docker, CI/CD etc, authentication.

Pushes to the main branch trigger a new container build with GitHub Actions and a deployment to Azure App Service here: https://mvc-test-i.azurewebsites.net/

## Run with Docker

```bash
docker build -t mvc-test -f MvcTest/Dockerfile .
docker run --rm -it -p 80:80 -p 443:443 mvc-test
```

## Deploy to Azure

Run main.bicep to create Azure resources.
