USE [dbase1]
GO
/****** Object:  StoredProcedure [inventory].[AddNewTime]    Script Date: 22.09.2020 12:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [inventory].[AddNewTime]		
	@id_kadr int ,
	@id_ttost int , 
	@timeS datetime = null,
	@timeEnd datetime = null,
	@type int,
	@scan varchar(150) = null,
	@idCreater int,
	@id_spacing int  = null
	
AS
BEGIN
	SET NOCOUNT ON;
	
 insert into inventory.j_scanerBlank 
	  (id_kadr
      ,id_ttost
      ,timeStart
      ,timeEnd
      ,[type]
      ,numberScaner
      ,id_Creator
      ,date_create,
	  id_spacing)
      values 
	  (@id_kadr,@id_ttost,
      --(select top(1)  convert(varchar(10), timeStart,102) from inventory.j_scanerBlank where id_kadr = @id_kadr and id_ttost = @id_ttost) +' '+ @timeS,
      --(select top(1)  convert(varchar(10), timeStart,102) from inventory.j_scanerBlank where id_kadr = @id_kadr and id_ttost = @id_ttost) +' '+ @timeEnd,
	  @timeS,
	  @timeEnd,
      @type,@scan,
      @idCreater,
	  GETDATE(),
	  @id_spacing)
 
END
