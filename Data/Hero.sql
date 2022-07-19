insert ignore into Contents.Sections 
(
    Name, 
    Supertitle, 
    Title, 
    Subtitle, 
    Description, 
    `Key`,
    PrimaryCtaText,
    PrimaryCtaLink,
    SecondaryCtaText,
    SecondaryCtaLink
)
values
(
    'Hero',
    'Taste the change',
    'Improve your life like never before',
    'Start today',
    'We believe that change starts from within. Thus we have united to help each other become a better version of us. A version that we want to be.',
    'hero',
    'Start today',
    '/start',
    'Watch how',
    '/watch'
);

select Id into @heroId
from Contents.Sections
where `Key` = 'hero';