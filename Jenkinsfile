pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_NOLOGO = 'true'
        BUILD_CONFIG = 'Release'
        PUBLISH_DIR = 'dist_deploy'
    }

    stages {
        stage('1. Checkout Git') {
            steps {
                checkout scm
            }        }

        stage('2. Restore NuGet') {
            steps {
                bat 'dotnet restore SistemaVendas.slnx'
            }
        }

        stage('3. Build Release') {
            steps {
                bat "dotnet build SistemaVendas.slnx --configuration ${BUILD_CONFIG} --no-restore"
            }
        }

        stage('4. Testes Unitários') {
            steps {
                bat "dotnet test SistemaVendas.slnx --configuration ${BUILD_CONFIG} --no-build --logger \"trx;LogFileName=resultados.trx\""
            }
            post {
                always {
                    mstest testResultsFile: '**/*.trx', keepLongStdio: true
                }
            }
        }

        stage('5. Empacotar (Publish)') {
            when {
                branch 'main'
            }
            steps {
                bat "dotnet publish src/SistemaVendas.Console/SistemaVendas.Console.csproj -c ${BUILD_CONFIG} -o ${PUBLISH_DIR} --no-build"
                archiveArtifacts artifacts: "${PUBLISH_DIR}/**/*", fingerprint: true
            }
        }

        stage('6. Deploy') {
            when {
                branch 'main'
            }
            steps {
                echo 'A copiar ficheiros compilados para a pasta de produção local...'
                bat "if not exist C:\\Deploy\\SistemaVendas mkdir C:\\Deploy\\SistemaVendas"
                bat "xcopy /E /I /Y ${PUBLISH_DIR}\\* C:\\Deploy\\SistemaVendas\\"
                echo 'Deploy concluído com sucesso!'
            }
        }
    }

    post {
        always {
            cleanWs()
        }
        failure {
            echo 'ERRO: O pipeline falhou. Verifique os logs acima.'
        }
    }
}
