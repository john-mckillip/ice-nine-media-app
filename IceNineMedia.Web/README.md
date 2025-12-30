# Ice Nine Media Umbraco 15 Application

An evolving web application for my personal website that leverages the following technologies:
- Umbraco 15
- .NET 9
- Blazor
- Tailwind CSS

## Development Workflow

### Watching for CSS Changes

To automatically rebuild the Tailwind CSS whenever changes are made to Razor views, 
CSS files, or other relevant files, you can use the following command: npm run watch:css

#### What It Does:

- Watches for changes in `.razor`, `.cshtml`, and `.css` files.
- Automatically rebuilds the `wwwroot/css/output.css` file using `postcss` and Tailwind CSS.

#### Prerequisites:

- Ensure all dependencies are installed by running: npm install

#### Usage:

1. Open a terminal in the `IceNineMedia.Web` directory.
2. Run the command: npm run watch:css
3. The command will keep running and rebuild the CSS whenever changes are detected.

#### Notes:

- The `output.css` file is ignored in version control (`.gitignore`) to avoid unnecessary merge conflicts.
- The `package-lock.json` file is committed to the repository to ensure consistent builds across environments and enable faster CI/CD builds with dependency caching.
- Ensure your browser is not caching the CSS during development. You can append a query string to the CSS file reference in your HTML, like so:

<link href="css/output.css?v=@DateTime.UtcNow.Ticks" rel="stylesheet">

### Building CSS for Production

To build the CSS once without watching for changes (useful for CI/CD pipelines), run: npm run build:css

#### Prerequisites:

- Ensure all dependencies are installed by running: npm install

#### Usage:

1. Open a terminal in the `IceNineMedia.Web` directory.
2. Run the command: npm run build:css
3. The command will generate the `wwwroot/css/output.css` file for production use.