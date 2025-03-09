docker manifest create `
AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-multiarch `
AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-arm `
AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-amd


docker manifest push AWS_ACCOUNT_NUMBER.dkr.ecr.us-west-2.amazonaws.com/sebs-multiarch:601-multiarch