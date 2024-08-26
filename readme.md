
# **Microservices Project with .NET 8, Ocelot, RabbitMQ, and Azure Service Bus**

## **Overview**

This project is a comprehensive microservices-based architecture built using .NET 8, designed to handle various functionalities such as product management, shopping cart, order processing, payments, and more. The architecture leverages Ocelot as the API Gateway, RabbitMQ and Azure Service Bus for reliable messaging, and follows Clean Architecture principles to ensure maintainability and scalability.

## **Microservices Included**

- **Product Microservice**: Manages product information, including creation, updates, and retrieval of product details.
- **Shopping Cart Microservice**: Handles user shopping carts, allowing users to add, remove, and view items in their carts.
- **Order Microservice**: Manages the entire order lifecycle from creation to completion.
- **Payment Microservice**: Processes payments and ensures secure transactions.
- **Email Microservice**: Sends order confirmations, promotional offers, and other notifications via email.
- **Coupon Microservice**: Manages discount coupons and applies them to user orders.
- **.NET Identity Microservice**: Manages user authentication and authorization, including secure user registration and login.
- **Ocelot API Gateway**: Acts as the single entry point for all client requests, routing them to the appropriate microservice.
- **MVC Web Application**: The frontend interface for users to interact with the various services.

## **Architecture Overview**

### **Ocelot API Gateway**

The **Ocelot API Gateway** is a crucial component in this architecture. It serves as the single entry point for all client interactions, routing requests to the appropriate backend microservice. By centralizing routing and security, Ocelot simplifies client interactions and enhances the security posture of the entire system.

#### **Example Configuration**

```json
"ProductAPI": "https://localhost:7000",
{
  "DownstreamPathTemplate": "/api/product",
  "DownstreamScheme": "https",
  "DownstreamHostAndPorts": [
    {
      "Host": "localhost",
      "Port": 7000
    }
  ],
  "UpstreamPathTemplate": "/api/product",
  "UpstreamHttpMethod": [ "Get" ]
},
{
  "DownstreamPathTemplate": "/api/product/{id}",
  "DownstreamScheme": "https",
  "DownstreamHostAndPorts": [
    {
      "Host": "localhost",
      "Port": 7000
    }
  ],
  "GlobalConfiguration": {
    "BaseUrl": "https://localhost:7777"
  }
}
```

This configuration shows how Ocelot routes requests from the frontend (upstream) to the appropriate backend microservice (downstream). In this example, requests to `/api/product` are routed to the Product Microservice running on `https://localhost:7000`.

### **RabbitMQ & Azure Service Bus**

**RabbitMQ** and **Azure Service Bus** are used for messaging between microservices. They ensure reliable communication, especially in scenarios where immediate responses are not required or when services need to be decoupled.

- **RabbitMQ**: Primarily used for event-driven communication between services. For example, when an order is placed, an event can be published to RabbitMQ, which other services (like the Email Microservice) can subscribe to and act upon.

- **Azure Service Bus**: Used for more complex messaging scenarios and ensures reliable message delivery. It is particularly useful for decoupling services. For instance, after a user registers, an event is published to Azure Service Bus. This event is then consumed by the Email Microservice to send a welcome email, and by the Shopping Cart Microservice to create an initial cart for the user.

### **Logging**

All necessary events and information are logged into the database, providing a comprehensive audit trail and aiding in troubleshooting. The use of RabbitMQ and Azure Service Bus ensures that all messages and events are reliably processed and logged.

### **Use Case Workflow**

1. **User Registration**: When a user registers, the .NET Identity Microservice handles authentication and authorization. An event is then published to Azure Service Bus.

2. **Email Notification**: The Email Microservice subscribes to the registration event from Azure Service Bus and sends a welcome email to the new user.

3. **Cart Initialization**: Simultaneously, the Shopping Cart Microservice subscribes to the same event and creates a default shopping cart for the user.

4. **Order Placement**: When an order is placed, the Order Microservice processes the order and publishes an event to RabbitMQ.

5. **Payment Processing**: The Payment Microservice listens for the order event and processes the payment.

6. **Logging**: Every action, from user registration to order completion, is logged into the database for auditing and analysis.

## **Tech Stack**

- **.NET 8 API**: Core framework for building the microservices.
- **Entity Framework Core**: ORM for interacting with SQL Server.
- **Ocelot API Gateway**: For routing and securing API requests.
- **RabbitMQ**: Message broker for event-driven communication.
- **Azure Service Bus**: Enterprise messaging service for reliable message delivery.
- **SQL Server**: Relational database for data persistence.
- **Clean Architecture**: Design principle ensuring the project is maintainable and scalable.

## **Getting Started**

To get started with this project, follow these steps:

1. **Clone the Repository**: 
   ```bash
   git clone <repository-url>
   ```

2. **Setup Environment**: 
   - Ensure .NET 8 is installed.
   - Setup SQL Server, RabbitMQ, and Azure Service Bus.

3. **Run Migrations**: 
   - Apply Entity Framework Core migrations to set up the database schema.
   ```bash
   dotnet ef database update
   ```

4. **Start Services**: 
   - Run each microservice individually using Visual Studio or through the command line.
   ```bash
   dotnet run --project <Microservice-Name>
   ```

5. **Access the Application**:
   - Use the Ocelot API Gateway's base URL to interact with the services.
   - The MVC Web Application can be accessed at `https://localhost:7777`.


## Watch the Project Overview Video

[![Watch the video](https://learn.microsoft.com/en-us/azure/architecture/includes/images/microservices-logical.png)](https://www.linkedin.com/posts/aarshdeep-chadha-42051a222_dotnet-microservices-azure-activity-7233775681363443712-aVqn?utm_source=share&utm_medium=member_desktop)


## **Conclusion**

This project demonstrates the power and flexibility of microservices architecture when combined with modern .NET technologies. By utilizing Ocelot, RabbitMQ, and Azure Service Bus, we ensure that the system is not only scalable but also reliable and maintainable. Whether you're dealing with user registrations, order placements, or complex messaging workflows, this architecture provides a robust foundation for building enterprise-level applications.
