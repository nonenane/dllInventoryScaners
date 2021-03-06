USE [dbase1]
GO
/****** Object:  StoredProcedure [inventory].[EditSingleTableForScaner]    Script Date: 22.09.2020 14:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Марченко А.А.>
-- Create date: <2016-06-09>
-- Description:	<Редактирование таблицы со временем выдачи сканеров и ведомостей>
-- =============================================
ALTER PROCEDURE [inventory].[EditSingleTableForScaner]
@id int,
@timeStart datetime,
@timeEnd datetime,
@id_Editor  int,
@id_spacing int  = null

AS
BEGIN


    SET NOCOUNT ON;
	SET XACT_ABORT ON;

begin try
begin transaction T1

    	UPDATE inventory.j_scanerBlank 
    	--set timeStart  = (select top(1)  convert(varchar(10), timeStart,102) from inventory.j_scanerBlank where id = @id) +' '+ @timeStart, 
    	    --timeEnd = (select top(1) convert(varchar(10), timeStart,102) from inventory.j_scanerBlank where id = @id) +' '+ @timeEnd 
		set
			timeStart = @timeStart,
			timeEnd= @timeEnd,
			id_spacing = @id_spacing,
			date_edit= GETDATE(),
			id_Editor  = @id_Editor  
    	where id = @id
    	
    	select 1
	
        commit transaction T1
end try	
begin catch
	IF (XACT_STATE()) = -1
	begin
		select ERROR_LINE() as line,ERROR_MESSAGE() as msg
		--select 0
		rollback transaction T1
	end
	IF (XACT_STATE()) = 1
	commit transaction T1
end catch

END
