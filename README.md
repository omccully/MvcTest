# MVC Test

Testing with various things like MVC, Docker, CI/CD etc.

## Run with Docker

```bash
docker build -t mvc-test -f MvcTest/Dockerfile .
docker run --rm -it -p 80:80 -p 443:443 mvc-test
```

## Deploy to Azure

Run main.bicep to create Azure resources.
