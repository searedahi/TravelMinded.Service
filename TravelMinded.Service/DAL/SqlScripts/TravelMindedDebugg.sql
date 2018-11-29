USE [TravelMinded]
GO

SELECT TOP 1000
	co.Name,
	ex.Name,	
	DATENAME(weekday,CONVERT(VARCHAR(10), av.StartAt, 112)),
	av.StartAt,
	av.EndAt,
	--av.ExperienceId,
	--ra.AvailabilityId,
	ra.Id as RateId,
	ra.capacity,
	pro.Total,
	pro.DisplayName,
	ct.singular
  FROM [dbo].[Companies] co
	  JOIN [TravelMinded].[dbo].[Experiences] ex ON co.Id = ex.CompanyId
	  JOIN [TravelMinded].[dbo].[Availabilities] av ON ex.Id = av.ExperienceId
	  JOIN [TravelMinded].[dbo].[CustomerTypeRate] ra ON av.Id = ra.AvailabilityId 
	  JOIN [TravelMinded].[dbo].[CustomerPrototype] pro ON ra.customer_prototypeId = pro.Id  
	  JOIN [TravelMinded].[dbo].[CustomerType] ct ON ra.customer_typeId = ct.Id
  WHERE co.Name = 'Oahu Photography Tours'
  ORDER BY
	  co.Id
	  ,ex.Id
	  ,av.StartAt


/*
BEGIN TRAN
	DELETE FROM [TravelMinded].[dbo].[CustomerTypeRate]
	DELETE FROM [TravelMinded].[dbo].[CustomerType]
	DELETE FROM [TravelMinded].[dbo].[CustomerPrototype]
	DELETE FROM [TravelMinded].[dbo].[ImageInfo]
	DELETE FROM [TravelMinded].[dbo].[Availabilities]
	DELETE FROM [TravelMinded].[dbo].[LocationInfo]
	DELETE FROM [TravelMinded].[dbo].[Experiences]		
	DELETE FROM [TravelMinded].[dbo].[Companies]
    DELETE FROM [TravelMinded].[dbo].[AddressInfo]

	DBCC CHECKIDENT ('[CustomerTypeRate]', RESEED, 0);
	DBCC CHECKIDENT ('[CustomerType]', RESEED, 0);
	DBCC CHECKIDENT ('[CustomerPrototype]', RESEED, 0);
	DBCC CHECKIDENT ('[ImageInfo]', RESEED, 0);
	DBCC CHECKIDENT ('[Availabilities]', RESEED, 0);
	DBCC CHECKIDENT ('[LocationInfo]', RESEED, 0);
	DBCC CHECKIDENT ('[Experiences]', RESEED, 0);
	DBCC CHECKIDENT ('[Companies]', RESEED, 0);
	DBCC CHECKIDENT ('[AddressInfo]', RESEED, 0);
ROLLBACK TRAN
*/




/*

BEGIN TRAN


SELECT  
	ExperienceId
	,COUNT(Id) as Images
FROM ImageInfo
GROUP BY ExperienceId

INSERT INTO [dbo].[ImageInfo]
           ([Pk]
		   ,[Gallery]
           ,[ImageCdnUrl]
           ,[ExperienceId])
     
	(
		SELECT 
		(SELECT MAX(id) + 1 FROM dbo.ImageInfo)
		,'Default images'
		,'https://c1.staticflickr.com/2/1312/5116561072_f2da4a0bd6_b.jpg'
		, Id
		FROM dbo.Experiences)



SELECT  
	ExperienceId
	,COUNT(Id) as Images
FROM ImageInfo
GROUP BY ExperienceId


/*
DELETE FROM ImageInfo
WHERE ImageCdnUrl = 'https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwimm4LfkuHeAhVWITQIHQ66BlQQjRx6BAgBEAU&url=https%3A%2F%2Fwww.flickr.com%2Fphotos%2Fhaywardphoto%2F5116561072&psig=AOvVaw06fHsdrP4vH4xzW6UNCV_i&ust=1542740592170711'
*/

ROLLBACK TRAN


*/
