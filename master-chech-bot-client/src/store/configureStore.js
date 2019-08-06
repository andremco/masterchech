import { env } from 'environs'
import prodStore from './configureStore.prod'
import devStore from './configureStore.dev'

export default env ? prodStore : devStore