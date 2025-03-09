$cert = New-SelfSignedCertificate -DnsName @("auth-server-name.test") -CertStoreLocation "cert:\LocalMachine\My"

$certKeyPath = "$env:USERPROFILE\.aspnet\https\auth-server-name.test.pfx"
$password = ConvertTo-SecureString 'password' -AsPlainText -Force
$cert | Export-PfxCertificate -FilePath $certKeyPath -Password $password
$rootCert = $(Import-PfxCertificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root' -Password $password)