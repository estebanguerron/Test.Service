# Test.Service
Test.Service

Servicio con autenticacion jwt
# 1. DataBase
  Ejecutar el archivo DataBase.sql
  
  Para la creacion del docker de la base de datos ejecutar el comando de InstallDatabase
  
# 2.Servicio
  Abrir la solucion Test.Service\Test.Service.sln
  
  Los servicios se puede probar con Postman
  
  GET autenticacion 
      http://localhost:15440/user?user=user&password=password

  DELETE Metodo Con autenticacion JWT, se debe ingresar el token generado en autenticacion 
      http://localhost:15440/colegio/EliminarColegio?id=3
      
      Verificar y actulizar las configuraciones principales en el archivo appsettings.json
  Configuracion de jwt y cadena de conexion
