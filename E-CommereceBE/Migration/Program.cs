// Tại Program.cs của Web API
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("Infrastructure") // Chỉ định rõ assembly chạy migration
    ));