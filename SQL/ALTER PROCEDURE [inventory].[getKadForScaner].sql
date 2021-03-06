USE [dbase1]
GO
/****** Object:  StoredProcedure [inventory].[getKadForScaner]    Script Date: 22.09.2020 10:38:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2015-12-04
-- Description:	Получение сотрудника по коду бейджика
-- =============================================
ALTER PROCEDURE [inventory].[getKadForScaner]		
	@code bigint = null,
	@numbejec bigint  = null
AS
BEGIN	
	SET NOCOUNT ON;

select 
	isnull(k.lastname+' ','')+
	isnull(k.firstname+' ','')+
	isnull(k.secondname,'') as FIO,
	convert(varchar(8),GETDATE(),108) as nowTime,
	convert(varchar(20),GETDATE(),104) as nowDate,
	p.id_Kadr as id_kadr
from 
	Personnel.s_PersonalData p
		left join s_kadr k on k.id=p.id_Kadr
where
	(@code  is not null and p.Code= @code)
	or (@numbejec is not null and k.NumberBeycik = @numbejec)

END
