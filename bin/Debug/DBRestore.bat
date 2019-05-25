cd /D C:\Program Files (x86)

cd PostgreSQL

cd 9.1

cd bin

pg_restore.exe --host localhost --port 5432 --username postgres --dbname "BdRaposo" --verbose "D:\RaposoFact\RaposoFact\Backup BD\BdRaposo_Backup_11092014_1108.backup"
