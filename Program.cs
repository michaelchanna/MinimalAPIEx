var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddSingleton<IUserProvider, UserProvider>();
builder.Services.AddSingleton<IUserCreator, UserCreator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// GET methods
app.MapGet("/api/user", ([FromServices]IUserProvider userProvider) => userProvider.Get())
	.WithName("Get User")
	.Produces<User>(StatusCodes.Status200OK);

// POST methods
app.MapPost("api/user", ([FromServices]IUserCreator userCreator, [FromBody] User user) 
	=> userCreator.Create(user) ? Results.Ok() : Results.BadRequest())
	.WithName("Create User")
	.Produces(StatusCodes.Status200OK)
	.Produces(StatusCodes.Status400BadRequest);

app.Run();












// Ex of function.
// var isGreaterThan10 = bool (int x) => x > 10;

