#docker manifest create AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:multiarch AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:arm AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:amd
#docker manifest push AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:multiarch

docker buildx imagetools create `
 -t AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601 `
 -t AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:latest `
 -t AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:test `
 -t AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:playpen-se `
 AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-arm `
 AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-amd