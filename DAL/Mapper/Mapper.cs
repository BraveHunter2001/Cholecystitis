using DAL.DTO;
using DAL.Model;

namespace DAL.Mapper;

public static class Mapper
{
    public static Patient ToPatient(this PatientDto patientDto, Guid patientId, Guid cholecystitId) =>
        new()
        {
            Id = patientId,
            Age = patientDto.Age,
            Gender = patientDto.Gender,
            Name = patientDto.Name,
            RiskFactors = patientDto.RiskFactors,
            CholecystitId = cholecystitId
        };

    public static PatientDto ToPatientDto(this Patient patient) =>
        new()
        {
            Name = patient.Name,
            Age = patient.Age,
            Gender = patient.Gender,
            RiskFactors = patient.RiskFactors,
        };

    public static Stone ToStone(this StoneDto stoneDto, Guid stoneId, Guid cholecystitId) =>
        new()
        {
            Id = stoneId,
            Type = stoneDto.Type,
            Color = stoneDto.Color,
            Composition = stoneDto.Composition,
            CholecystitId = cholecystitId
        };

    public static void StoneDtoPushToStone(this Stone stone, StoneDto dto)
    {
        stone.Color = dto.Color;
        stone.Type = dto.Type;
        stone.Composition = dto.Composition;

    }
}