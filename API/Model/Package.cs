namespace API.Model;

public record Package
{
    public Guid id { get; init; }
    public string createdBy { get; init; } = default!; // Pega o nome dele do TokenJWT
    public Guid userId { get; init; } // Vem la do TokenJWT, o id é usuario ou Admin

    public DateTime updatedAt { get; set; } // Vai mostra quando occoreu a última atualização no banco de datos
    public Status status { get; set; } // 

    public Details Details { get; init; } = default!;
}