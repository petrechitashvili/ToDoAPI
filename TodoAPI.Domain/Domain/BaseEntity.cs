namespace TodoAPI.Domain.Domain;

protected abstract class BaseEntity<TId>
{
    public long TId { get; protected set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? DeleteDate { get; private set; }

    public DateTime? LastModifiedDate { get; private set; }
}

protected abstract class BaseEntity : BaseEntity<long>
{
    
}

// Just use https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Entity/Entity.cs
