echo off
if not exist terraform.exe (
	powershell -Command "Invoke-WebRequest https://releases.hashicorp.com/terraform/1.6.4/terraform_1.6.4_windows_amd64.zip -OutFile terraform_1.6.4_windows_amd64.zip"
	powershell -Command "Expand-Archive terraform_1.6.4_windows_amd64.zip -DestinationPath ./ -Force"
)

powershell -Command "./terraform.exe init"
print Terraform init

powershell -Command "./terraform.exe plan"
print Terraform plan

powershell -Command "./terraform.exe apply --auto-approve"
print Terraform apply