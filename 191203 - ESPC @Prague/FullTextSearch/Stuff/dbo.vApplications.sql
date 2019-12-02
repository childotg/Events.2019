SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vApplications]
AS
SELECT  TOP 500      'T1-'+TRIM(STR(AppId)) as AppId, 
				AppName, 
				AppCategory, 
				AppRating, 
				AppReviews, 
				AppSizeInKb, 
				CASE
					WHEN AppSizeInKb<10000 THEN '<10MB' 
					WHEN AppSizeInKb<50000 THEN '10MB-50MB'
					ELSE '>50MB'
				END as AppSize,
				AppInstalls, 
				CASE WHEN AppType=0 THEN 'Free' ELSE 'Paid' END as AppType,
				AppPrice, 
				AppContentRating, 
				'["'+REPLACE(AppGenres,'|','","')+'"]' as AppGenres,
				AppLastUpdate, 
				AppVersion, 
				AppAndroidRequirement
FROM            dbo.Applications
GO


