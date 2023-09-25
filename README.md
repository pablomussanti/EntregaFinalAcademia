# EntregaFinalAcademia
El proyecto está desarrollado con Net Core 6 con Entity Framework Core y SQL SERVER 2022
​
## **Especificación de la Arquitectura**
​
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext y crearemos los seeds correspondientes parapopular nuestras entidades.
​
### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo

### **Capas Extras**
* Infraestructure: ​En este nivel se declaran las response a las distintas request
*	Services: Se incluirán todos los servicios solicitados por el proyecto.
*	DTOS: se definirán los modelos que necesitemos para el desarrollo
*	Helper: Definiremos lógica que pueda ser de utilidad para todo el proyecto. Por ejemplo, algún método para encriptar/desencriptar contraseñas
*	Migrations: se encuentran los modelos generados por Entity Framework Core
​
## **Especificación de GIT**

* Se crearon ramas a partir de develop, la cuales se le agregan distintas Feactures para ir integrando y manejando la trazabilidad de cada implementacion.
