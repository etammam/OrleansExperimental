using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis")
.WithRedisInsight();

var orleans = builder.AddOrleans("orleans")
    .WithClustering(redis);

var customerApiCluster = orleans.WithServiceId("customers-service");
var orderApiCluster = orleans.WithServiceId("orders-service");
var dashboardCluster = orleans.WithServiceId("dashboard-service");

builder.AddProject<OrleansExperimental_Customers_Api>("customers-api")
    .WithReference(customerApiCluster);
builder.AddProject<OrleansExperimental_Orders_Api>("orders-api")
    .WithReference(orderApiCluster);
builder.AddProject<OrleansExperimental_Dashboards_Orleans>("dashboards-orleans")
    .WithReference(dashboardCluster);

builder.Build().Run();