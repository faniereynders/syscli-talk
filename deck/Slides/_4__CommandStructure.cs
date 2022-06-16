public class _4__CommandStructure : BulletedSlide
{
    public override int Index => 5;
    protected override string Title => "Cmd Structure";
    protected override string[] Bullets => new string[]
    {
        "Driver",
        "Command",
        "Arguments",
        "Options",
    };
    protected override string[] Footers => new string[]{
        @"dotnet {app}",
        "dotnet {command} [arguments] [--options]"
    };
}
