using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCase.Pets.GetAll;
public class GetAllPetsUseCase
{
    public ResponseAllPetsJson Execute()
    {
        return new ResponseAllPetsJson
        {
            Pets = new List<ResponseShortPetJson>
            {
                new ResponseShortPetJson
                {
                    Id = 1,
                    Name = "Test",
                    Type = Communication.Enums.PetType.Dog,
                }
            }
        };
    }
}
