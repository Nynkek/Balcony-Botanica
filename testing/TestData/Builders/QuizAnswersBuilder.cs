using BalconyBotanica.Core.DomainObjects;

namespace MyTestProject;

public class QuizAnswersBuilder : Builder<QuizAnswers>
{
    private Sunlight _sunlight = Sunlight.FULL_SHADE;
    private int _spaceSizeSquareMeters = 4;
    private WateringSchedule _wateringSchedule = WateringSchedule.MINIMUM;
    private PlantFunction _plantFunction = PlantFunction.EDIBLE;
    private Toxicity _toxicity = Toxicity.NONE;

    public QuizAnswersBuilder WithSunlight(Sunlight sunlight)
    {
        _sunlight = sunlight;
        return this;
    }

    public QuizAnswersBuilder WithSpaceSizeSquareMeters(int spaceSizeSquareMeters)
    {
        _spaceSizeSquareMeters = spaceSizeSquareMeters;
        return this;
    }

    public QuizAnswersBuilder WithWateringSchedule(WateringSchedule wateringSchedule)
    {
        _wateringSchedule = wateringSchedule;
        return this;
    }

    public QuizAnswersBuilder WithPlantFunction(PlantFunction plantFunction)
    {
        _plantFunction = plantFunction;
        return this;
    }

    public QuizAnswersBuilder WithToxicity(Toxicity toxicity)
    {
        _toxicity = toxicity;
        return this;
    }

    public override QuizAnswers Build()
    {
        return new QuizAnswers(_sunlight, _spaceSizeSquareMeters, _wateringSchedule, _plantFunction, _toxicity);

    }
}
