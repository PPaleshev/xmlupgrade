namespace XmlUpgrade.Core
{
    public interface IXmlTransformationCommand
    {
        void Execute(IXmlTransformContext context);
    }
}