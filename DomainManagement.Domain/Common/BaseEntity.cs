namespace DomainManagement.Domain.Common
{
    // This abstract class serves as a base for all entity classes in the application.
    // It contains common properties that are shared across different entities, 
    // ensuring consistency and reducing code duplication.
    public abstract class BaseEntity
    {
        // The 'Id' property serves as the unique identifier for each entity instance.
        // It is typically used as the primary key in the database.
        public int Id { get; set; }

        // The 'DateCreated' property holds the date and time when the entity was created.
        // It can be used for auditing and tracking purposes. It's nullable to ensure that 
        // if it's not set, it doesn't default to a DateTime's default value.
        public DateTime? DateCreated { get; set; }

        // The 'DateModified' property holds the date and time when the entity was last modified.
        // Like 'DateCreated', it helps in auditing and is nullable to handle cases where 
        // the entity hasn't been modified yet.
        public DateTime? DateModified { get; set; }
    }
}
