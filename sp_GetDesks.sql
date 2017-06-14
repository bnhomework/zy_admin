USE [bn_zy]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDesks]    Script Date: 2017/6/14 20:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetDesks]
  ( 
    @shopId uniqueIdentifier, 
    @date datetime
  ) 
  AS
  BEGIN
    select DeskId,DeskName,booked.position as [BookedPositions],internlbooked.position as [InternalBookedPositions] from ZY_Shop_Desk a
	outer apply (select CONVERT(nvarchar(256),b.Position)+',' from ZY_Booked_Position b where b.DeskId=a.DeskId and b.Status=1 and b.OrderDate=@date for xml path(''))as booked(position)
	outer apply (select CONVERT(nvarchar(256),b.Position)+',' from ZY_Booked_Position b where b.DeskId=a.DeskId and b.Status=1 and b.OrderDate=@date and b.IsInternal=1 for xml path(''))as internlbooked(position)
	where ShopId=@shopId
	order by DeskName
  END