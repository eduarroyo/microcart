~~~~
Enunciado generado por chatgpt a partir del siguiente prompt: propón una prueba técnica para un desarrollador .net senior que implique el uso de microservicios y que se pueda resolver en 3h
~~~~

# microcart
Sistema de gestión de pedidos basado en microservicios

## Descripción
Debes desarrollar una pequeña aplicación de microservicios usando .NET 6 o .NET 7, que simule un sistema de gestión de pedidos. El sistema debe permitir a los usuarios realizar pedidos de productos y realizar algunas operaciones básicas sobre ellos. Los microservicios deben estar desacoplados, ser escalables y comunicarse entre sí usando REST o eventos (dependiendo de tu preferencia).

## Requerimientos

### Microservicio de Gestión de Pedidos

#### Funcionalidad
Este servicio debe permitir crear, actualizar y obtener pedidos. Un pedido tiene un ID, una lista de productos, una cantidad, y un estado (pendiente, completado, cancelado).

#### Tecnologías
ASP.NET Core Web API
Uso de base de datos (In-Memory DB o SQLite para simplificar)
Métodos RESTful para operaciones CRUD

### Microservicio de Gestión de Productos

#### Funcionalidad
Este servicio debe gestionar los productos, con operaciones básicas como agregar, actualizar, obtener lista de productos y eliminar.

### Tecnologías:
ASP.NET Core Web API
In-Memory DB o SQLite

### Comunicación entre microservicios
Los microservicios deben comunicarse a través de llamadas REST o, si prefieres un enfoque más avanzado, puedes implementar comunicación asincrónica usando un sistema de mensajería (como RabbitMQ o Azure Service Bus).
Pruebas de Integración:

Escribe pruebas para asegurar que la comunicación entre los microservicios funcione correctamente. Asegúrate de probar los casos de éxito y error de la creación de pedidos, incluyendo la validación de la disponibilidad del producto antes de crear un pedido.
Documentación:

## Documentación
Proporciona una breve documentación (en un archivo README.md) sobre cómo correr los servicios y cómo probar las APIs (por ejemplo, con Postman o Swagger).
Incluye detalles sobre cómo escalabilidad, resiliencia y trazabilidad pueden ser abordadas (por ejemplo, manejo de errores, retries, logging).
Requisitos adicionales:
Implementación de un patrón básico de autenticación (JWT, OAuth) para proteger las API de pedidos.
En el microservicio de pedidos, valida que los productos en el pedido existan en el microservicio de productos antes de crear un pedido.
Considera el uso de contenedores Docker para empaquetar los microservicios y ejecutarlos de forma aislada.

## Objetivos
* Demostrar la capacidad para desarrollar una arquitectura de microservicios utilizando .NET Core.
* Implementar la comunicación entre microservicios.
* Crear pruebas unitarias y de integración que aseguren la correcta funcionalidad del sistema.
* Mostrar cómo manejar una base de datos simple en un contexto de microservicios.
* Criterios de evaluación:
* Correcta implementación de las APIs.
* Diseño limpio y modular de los microservicios.
* Calidad del código (legibilidad, pruebas unitarias, patrones de diseño).
* Capacidad de integración entre los microservicios.
* Uso adecuado de herramientas como Docker y bases de datos ligeras para desarrollo.


## Notas
La prueba está pensada para que el candidato pueda demostrar sus habilidades en arquitectura de microservicios, desarrollo de APIs REST, pruebas y escalabilidad. Si hay alguna parte que no se pueda completar por el tiempo, es aceptable realizarla parcialmente o de forma simplificada, pero se valorará más la calidad del diseño y la organización del código.
