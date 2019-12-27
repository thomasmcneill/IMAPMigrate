# IMAPMigrate
Migrate between two IMAP servers or download all IMAP messages to a folder

This application allows to download all IMAP messages.  It shows you a tree and you can select folders.  The folders show a message count.  You are given the option to download all messages to a folder.  All subfolders are automatically created on the hard drive.  Or you can push them to another IMAP account.

Gathering folders and message count is a background thread so that the UI can be updated as it gathers information. 
Saving to disk is also a background thread.  The message count is reduced per folder to reflect process





