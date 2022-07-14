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
    'Items have secondary CTA',
    'Users can add one more CTA. It would be considered secondary and less important.',
    'ItemsHaveSecondaryCta'
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
        where `Key` = 'ItemsHaveSecondaryCta'
    )
);