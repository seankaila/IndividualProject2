app_service {
  S1 = {
    name = "SeanFrontEnd-app-service"
  },
  S2 = {
    name = "SeanService2-app-service"
  },

  S3 = {
    name = "SeanServie3-app-service"
  },

  S4 = {
    name = "SeanServie4-app-service"
  }
}

provider "azurerm" {
  features {} 
}
resource "azurerm_resource_group" "main" {
  name     = "seans-resources"
  location = "Uk West"
}

resource "azurerm_app_service_plan" "main" {
  name                = "sean-appserviceplan"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "main" {
  for_each = var.app_service
  name                = var.app_service.name
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  app_service_plan_id = azurerm_app_service_plan.main.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "Service4URL": "https://SeanServie4-app-service.azurewebsites.net"
    "Service3URL": "https://SeanServie3-app-service.azurewebsites.net"
    "Service2URL": "https://SeanServie2-app-service.azurewebsites.net"
  }

  connection_string {
    name  = "Database"
    type  = "MySQLServer"
    value = "Server=seankailadbserver.mysql.database.azure.com; Port=3306; Database=HistoryDB; Uid=seankaila@seankailadbserver; Pwd=Password123;"
  }
}

resource "azurerm_mysql_server" "main" {
  name                = "seankailadbserver"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  administrator_login          = "seankaila"
  administrator_login_password = "password123"

  sku_name   = "B_Gen5_2"
  storage_mb = 5120
  version    = "5.7"

  auto_grow_enabled                 = false
  backup_retention_days             = 0
  geo_redundant_backup_enabled      = true
  infrastructure_encryption_enabled = true
  public_network_access_enabled     = false
  ssl_enforcement_enabled           = true
  ssl_minimal_tls_version_enforced  = "TLS1_2"
}

resource "azurerm_mysql_database" "main" {
  name                = "Historydb"
  resource_group_name = azurerm_resource_group.main.name
  server_name         = azurerm_mysql_server.main.name
  charset             = "utf8"
  collation           = "utf8_unicode_ci"
}