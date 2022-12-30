// Vars
buildName = "Gamebuild ${BUILD_NUMBER}"
UNITY_PATH = "~/Unity/Hub/Editor/2022.1.17f1/Editor/Unity"
UNITY_Project = "/var/lib/jenkins/workspace/UnityJenkinsExample/UnityJenkinsExample"
BUILD_PATH  = "/var/lib/jenkins/workspace/UnityJenkinsExample/UnityJenkinsExample"

pipeline {
	parameters {
		booleanParam(name: 'SEND_TO_DISCORD', defaultValue: true, description: 'Push a post to discord, letting us know how the build went.')
	}

    agent any
    stages {
        stage('Start') {
            steps {
                echo "Build process starting: ${buildName}"
            }
        }
		
		stage('Build') {
			steps {
				echo 'Build stage started'
				sh "\"${UNITY_PATH}" -projectPath ${UNITY_Project} -nographics -buildWindows64Player ${BUILD_PATH}"
			}
		}
		
		stage('Post') {
			steps {
				echo 'Post stage started'
			}
		}
		
    }
	
	// This is where all the end of work stuff is reported (and typically posted somewhere like discord)
	post {
    always {
      discordSend description: 'Jenkins Pipeline Build', footer: "${buildName} has been built", link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discordapp.com/api/webhooks/1057856859467419720/4n5NOSkLLIFkyeT2jirZEjHWzjOfqevMHdaNJ5iIccSgARCOBuyDdFruqy75MLOGu5gi'
    }
  }
}
