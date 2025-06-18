namespace PetshopAPISystem.infra.Configs;

public class Configuration
{
    public static string PrivateKey { get; set; } = "MySuperSecretPrivateKey1234567890!@#";  //Should not be hardcoded, its supposed to be a environment variable or something like that but as a test, gonna be like that by now
}