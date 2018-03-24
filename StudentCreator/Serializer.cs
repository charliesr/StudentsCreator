namespace StudentCreator
{
    public class Serializer
    {
        private BaseParser _parser;
        public Serializer(BaseSerializerFactory factory)
        {
            _parser = factory.CreateParser();
        }

        public void ExecuteAppend(string filename, Student student)
        {
            _parser.Append(filename, student);
        }
    }
}