insert ignore into Configuration.ConfigItems
(
    ConfigTypeId,
    Name,
    Description,
    `Key`
)
values
(
    (
        select Id
        from Configuration.ConfigTypes 
        where `Key` = 'Boolean'
    ),
    'Variable Items',
    'When enabled lets user add or remove items from a section.',
    'VariableItems'
);

insert ignore into Configuration.EntityConfigItems
(
    EntityTypeGuid,
    ConfigItemId
)
values
(
    (
        select Guid
        from Entities.EntityTypes
        where Name = 'section'
    ),
    (
        select Id 
        from Configuration.ConfigItems
        where `Key` = 'VariableItems'
    )
);