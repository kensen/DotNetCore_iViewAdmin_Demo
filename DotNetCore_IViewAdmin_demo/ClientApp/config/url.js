import env from './env'

const DEV_URL = 'http://localhost:5000'
const PRO_URL = 'http://localhost:8081'

export default env === 'development' ? DEV_URL : PRO_URL
