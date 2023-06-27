
param location string = 'East US 2'
param name string = 'mvc-test-app'


resource mvc_test_container_registry 'Microsoft.ContainerRegistry/registries@2022-12-01' {
  name: '${name}-acr'
  location: location
  sku: {
    name: 'Basic'
  }
  adminUserEnabled: true
}

resource mvc_test_app_server 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: '${name}-server'
  location: location
  kind: 'linux'
  sku: {
    name: 'F1'
    tier: 'Free'
  }
}

resource mvc_test_app 'Microsoft.Web/sites@2022-09-01' = {
  location: location
  name: name
  kind: 'container'
}




