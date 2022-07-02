insert ignore into Contents.Sections 
(
    Name, 
    Supertitle, 
    Title, 
    Subtitle, 
    Description, 
    `Key`
)
values
(
    'Hero',
    'Taste the change',
    'Improve your life like never before',
    'Start today',
    'We believe that change starts from within. Thus we have united to help each other become a better version of us. A version that we want to be.',
    'hero'
);

select Id into @heroId
from Contents.Sections
where `Key` = 'hero';

replace into Contents.Actions
(
    SectionId,
    CtaText,
    CtaLink
)
values
(
    @heroId,
    'Start today',
    '/start'
),
(
    @heroId,
    'Watch how',
    '/watch'
);