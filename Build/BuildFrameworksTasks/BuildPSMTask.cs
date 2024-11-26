
namespace BuildScripts;

[TaskName("Build PSM")]
public sealed class BuildPSMTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
        => context.DotNetPack(context.GetProjectPath(ProjectType.Framework, "PSM"), context.DotNetPackSettings);
}
