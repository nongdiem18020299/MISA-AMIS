import Vue from 'vue';
import App from './App.vue';
import Bus from './js/bus';
import VTooltip from 'v-tooltip';
import VueRouter from 'vue-router';
import {router} from './js/router/router';

Vue.use(VueRouter)

Vue.use(VTooltip)
Vue.use(Bus)

import { DraggablePlugin, DraggableDirective } from '@braks/revue-draggable';

// Use as Plugin
Vue.use(DraggablePlugin)

// or
Vue.directive('draggable', DraggableDirective)
Vue.directive('tooltip', VTooltip.VTooltip)
Vue.directive('close-popover', VTooltip.VClosePopover)
Vue.component('v-popover', VTooltip.VPopover)
// Vue.component('Draggable', Draggable)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
