using D02_EF6_CF;

try
{
    // Create and save a new Blog
    Console.Write("Digite o nome do novo blog (pressione 'Enter' para seguir sem criar novo blog): ");
    var name = Console.ReadLine();
    var blog = new Blog();

    if (name != string.Empty)
    {
        blog.Name = name;
        blog.Create();
    }

    var blogs = BlogController.ListAll();

    Console.WriteLine("\n\n------------------------------\nTodos os blogs\n------------------------------");
    blogs.ForEach(b => Console.WriteLine($"{b.BlogId} - {b.Name}"));

    // Create and save a new Blog
    Console.Write("\n\nDigite o índice do Blog para o qual deseja incluir um post: ");
    var selectedBlog = Console.ReadLine();
    _ = int.TryParse(selectedBlog, out int blogId);

    if (blogs.Any(b => b.BlogId == blogId))
    {
        // Create and save a new Post
        Console.Write("Digite o títlo do novo post no blog: ");
        var title = Console.ReadLine();

        Console.WriteLine("Digite o conteúdo do novo post:");
        var content = Console.ReadLine();

        var post = new Post
        {
            Title = title,
            BlogId = blogId,
            Content = content
        };

        post.Create();

        Console.WriteLine("\n\n------------------------------\nPost criado\n------------------------------");
        Console.WriteLine($"{post.PostId} - {post.Title}\n{post.Content}");
    }

}
catch (Exception e)
{
    Console.WriteLine($"Ocorreu um erro!\n{e.Message}\n");
}
finally
{
    Console.ReadLine();
}