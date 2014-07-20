namespace LabyrinthGame.Configuration
{
    using LabyrinthGame.Interfaces;
    using Ninject.Modules;

    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRandomCharProvider>().To<RandomCharProvider>();
            this.Bind<IRenderer>().To<ConsoleRenderer>();
        }
    }
}