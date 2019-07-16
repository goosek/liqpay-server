IF COL_LENGTH('[dbo].[rl_liqpay_donate_info]', 'Created_Date') IS NULL
BEGIN
    ALTER TABLE [dbo].[rl_liqpay_donate_info]
    ADD [Created_Date] DateTime
END