# Nexus-Validations-Tools
  [![GitHub license](https://img.shields.io/github/license/JuanDouglas/Nexus-Validations-Tools)](./LICENSE) [![GitHub forks](https://img.shields.io/github/forks/JuanDouglas/Nexus-Validations-Tools)](https://github.com/JuanDouglas/Nexus-Validations-Tools/network)

Ferramentas de validação da Nexus é um pacote [Nuget](https://nuget.org) com um conjunto de ferramentas (atributos validáveis, metodos de formatação e etc..) para validação e formatação de propiedades em classes modelo (usando o esquema MVC ) utilizando atributos. Esse pacote feito por [Juan Douglas](https://github.com/JuanDouglas), feito em nome e para a [Nexus Company](https://github.com/JuanDouglas).
> Para saber sobre versões e atualizações click [aqui]()

> Saiba como usar e veja exemplos [aqui](#usos-e-exemplos).

# Atributos 
Esta lista contém os atributos que serão ou já foram implementados ou a serem implementados 

  ':heavy_check_mark:' Atributo já implementado  
  
  ':x:' Atributo a ser implementado
 ## Atributos de classes modelos 
  Esses atributos são usados para validar classes modelo 
- ✔️ **Required:** O campo e obrigatório e não aceita valores nulos.
- ✔️ **Boolean:** O deve conter um valor booleano sabendo que pode ser sempre verdadeiro ou falso.
- ✔️ **CpfOrCnpj:** O deve conter um CPF ou CPNJ válido (use CPFOnly ou CNPJOnly caso queira um dos dois).
- ✔️ **Phone:** O campo deve conter um numéro de telefone válido.
- ✔️ **HttpUrl:** O campo deve uma URL válida com schema HTTP ou somente HTTPS.
- ✔️ **TimeSpan:** O campo deve conter um valor que representa um espaço de tempo com um numero máximo de Ticks.
- ✔️ **Name:** O campo deve conter um nome separado por ' '.
- ✔️ **Password:** O campo contém uma senha por isso deve conter uma letra minúscula, uma letra de maiúscula, um número e um caráter especial, além de ter no mínimo 8 caracteres.
- ✔️ **EmailAdress:** Este atributo indica que o campo deve ser um e-mail seguindo o esquema user@domain.org [RFC 822](https://datatracker.ietf.org/doc/html/rfc822#section-6).
- ✔️ **Compare:** Este atributo indica que o campo deve ter o mesmo valor do campo referenciado.
## Atributos de metodos 
- ✔️ **RequireAuthentication:** Este atributo irá indicar que um contéudo deve ser acessado usando uma autenticação válida.
- ✔️ **AllowAnonymous:** Este atributo irá indicar que um cotéudo pode ser acessado por qualquer um.
# Usos e exemplos 
Para utilizar os atributos e necessário adicionar o pacote [Nexus.Tools.Validation](https://www.nuget.org/packages/Nexus.Tools.Validations/), você pode adicionar o pacote utilizando o comando: 
```
 dotnet add package Nexus.Tools.Validations
```
Este exemplo mostra um exemplo de uma classe modelo com atributos nome é e-mail onde todo a validação é feita usando os atributos da classe 
> Para saber mais sobre os atribtuos e suas funcionalidades click [aqui](#atributos)

Exemplo: 
``` C#
using Nexus.Tools.Validations.Attributes;

namespace Example.Models
{
    public class ExampleModel
    {
        [Required]
        [EmailAddress]
        [StringLength(500)]
        [UniqueInDataBase(typeof(DbContext), typeof(Account), nameof(Account.Email))]
        public string Email { get; set; }

        [Password]
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
        
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
```