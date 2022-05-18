namespace TechTest
{
    using MediatR;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddMediatR(typeof(Program));
            var app = builder.Build();
            app.MapControllers();
            app.Run();
        }
    }
}
