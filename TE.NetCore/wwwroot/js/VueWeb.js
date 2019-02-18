new Vue({
    el: '#app',
    data: {
        seen: true,
        ok: false
    }
})
new Vue({
    el: '#app1'
})
new Vue({
    el: '#app2',
    data: {
        type: '5'
    }
})
new Vue({
    el: '#app3',
    data: {
        sites: [
            { name: 'Runoob' },
            { name: 'Goodle' },
            { name: 'Tianmao' }
        ]
    }
})
new Vue({
    el: '#app4',
    data: {
        counter:0
    }
})
var app5=new Vue({
    el: 'app5',
    data: {
        name:'Vue.js'
    },
    methods: {
        greet: function (event) {
            //alert('Hello' + this.name + '!')
            if (event) {
                alert(event.target.tagName)
            }
        }
    }
})
app5.greet();
new Vue({
    el: '#app6',
    methods: {
        say: function (message) {
            alert(message)
        }
    }
});
new Vue({
    el: '#app7',
    data: {
        message: 'Vue.js',
        message2:'前端框架：https://cn.vuejs.org/v2'
    }
})
new Vue({
    el: '#app8',
    data: {
        checked: false,
        checkedNames:[]
    }
})
new Vue({
    el: '#app9',
    data: {
        picked:"Google"
    }
})
new Vue({
    el: '#app10',
    data: {
        selected:''
    }
})
Vue.component('runoob', {
    template:'<h1>自定义组件！</h1>'
})
var Child = {
    template:'<h1>自定义组件！</h1>'
}
new Vue({
    el: '#app11',
    components: {
        'runoob':Child
    }
})
Vue.component('child', {
    props: ['message'],
    template:'<span>{{message}}</span>'
})
new Vue({
    el:'#app12'
})
Vue.component('child', {
    props: ['message'],
    template:'<span>{{message}}</span>'
})
new Vue({
    el: '#app13',
    data: {
        parentMsg:'父组件内容'
    }
})
Vue.component('todo-item', {
    props: ['todo'],
    template:'<li>{{todo.text}}</li>'
})
new Vue({
    el: '#app14',
    data: {
        sites: [
            { text: 'Konghey' },
            { text: 'Google' },
            { text: 'Tianmao' }
        ]
    }
})
Vue.component('example', {
    props: {
        // 基础类型检测 （`null` 意思是任何类型都可以）
        propA: Number,
        // 多种类型
        propB: [String, Number],
        // 必传且是字符串
        propC: {
            type: String,
            required: true
        },
        // 数字，有默认值
        propD: {
            type: Number,
            default: 100
        },
        // 数组／对象的默认值应当由一个工厂函数返回
        propE: {
            type: Object,
            default: function () {
                return { message: 'hello' }
            }
        },
        // 自定义验证函数
        propF: {
            validator: function (value) {
                return value > 10
            }
        }
    }
})
Vue.component('button-counter', {
    template: '<button v-on:click="incrementHandler">{{counter}}</button>',
    data: function () {
        return {
            counter:0
        }
    },
    methods: {
        incrementHandler: function () {
            this.counter += 1
            this.$emit('increment')
            
        }
    }
})
new Vue({
    el: '#counter-event-example',
    data: {
        total:0
    },
    methods: {
        incrementTotal: function () {
            this.total+=1
        }
    }
})
var buttonCounter2Data = {
    count:0
}
Vue.component('button-counter2', {
     /*
    data: function () {
	    // data 选项是一个函数，组件不相互影响
        return {
            count: 0
        }
    },
    */
    data: function () {
        return buttonCounter2Data
    },
    template : '<button v-on:click="count++">点击了{{count}}次。</button>'
})
new Vue({ el: "#components-demo3" })
//注册一个全局自定义指令v-focus
Vue.directive('focus', {
    //当绑定元素插入到DOM中。
    inserted: function (el) {
        //聚焦元素
        el.focus()
    }
})
//创建根实例
new Vue({
    el:'#app16'
})

Vue.directive('konghey', {
    bind: function (el, binding, vnode) {
        var s = JSON.stringify
        el.innerHTML = 'name:' + s(binding.name) + '<br>' +
            'value:' + s(binding.value) + '<br>' +
            'expression:' + s(binding.expression) + '<br>' +
            'argument:' + s(binding.argument) + '<br>' +
            'modifiers:' + s(binding.modifiers) + '<br>' +
            'vnode keys:' + Object.keys(vnode).join(',')
    }
})
new Vue({
    el: '#app17',
    data: {
        message:'Vue.js'
    }
})
Vue.directive('konghey', function (el, binding) {
    //简写方式设置文本及背景颜色
    el.innerHTML = binding.value.text
    el.style.backgroundColor = binding.value.color
})
new Vue({
    el:'#app18'
})

//0.如果使用模块化机制编程，导入Vue和VueRouter,要调用Vue.use(VueRouter)
//1.定义（路由）组件。
//可以从其他文件import进来
const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }
//2.定义路由
//每个路由应该映射一个组件。其中“component”可以是
//通过Vue.extend() 创建的组件构造器，
//或者，只是一个组件配置对象
//我们晚点再讨论嵌套路由
const routes = [
    { path: '/foo', component: Foo },
    { path: '/bar', component: Bar }
]
//3.创建router实例，然后传‘routes’配置
//你还可以传别的配置参数
const router = new VueRouter({
    routes  // （缩写）相当于 routes: routes
})
// 4. 创建和挂载根实例。
// 记得要通过 router 配置参数注入路由，
// 从而让整个应用都有路由功能
const app = new Vue({
    router
}).$mount('#app19')

new Vue({
    el: '#databinding',
    data: {
        show: true,
        styleobj: {
            fontSize: '30px',
            color:'red'
        }
    },
    methods: {
    }
})
new Vue({
    el: '#databinding1',
    data: {
        show: true
    }
})
new Vue({
    el: '#databinding2',
    data: {
        show: true
    }
})
new Vue({
    el: '#databinding3',
    data: {
        show: true
    },
    methods: {
        beforeEnter: function (el) {
            el.style.opacity = 0
            el.style.transformOrigin='left'
        },
        enter: function (el, done) {
            Velocity(el, { opacity: 1, fontSize: '1.4em' }, { duration: 300 })
            Velocity(el, { fontSize: '1em' }, { complete: done })
        },
        leave: function (el, done) {
            Velocity(el, { translateX: '15px', rotateZ: '50deg' }, { durantion: 600 })
            Velocity(el, { rotateZ: '100deg' }, { loop: 2 })
            Velocity(el, {
                rotateZ: '45deg',
                translateY: '30px',
                translateX: '30px',
                opacity: 0
            }, { complete: done })
        }
    }
})


window.onload = function () {
    var vm = new Vue({
        el: '#box1',
        data: {
            msg: 'Hello World！',
        },
        methods: {
            get: function () {
                //发送get请求
                this.$http.get('').then(function (res) {
                    document.write(res.body);
                }, function () {
                    console.log('请求失败处理');
                });
            }
        }
    });
    var vm1 = new Vue({
        el: '#box2',
        data: {
            msg:'Hello World'
        },
        methods: {
            post: function () {
                //发送post请求
                this.$http.post('/WebFrame/Bootstrap', { name: "Bootstrap.js", url: "https://www.konghey.com" }, { emulateJSON: true }).then(function (res) {
                    document.write(res.body);
                }, function (res) {
                    console.log(res.status);
                });
            }
        }
    })
}
var vm2 = new Vue({
    el: '#app20',
    data: {
        counter: 1
    }
});
vm2.$watch('counter', function (nval, oval) {
    //alert('计数器值的变化：' + oval + '变为' + nval + '!');
});
setTimeout(
    function () {
        vm2.counter += 20;
    },10000);

var myproduct = { "id": 1, name: "book", "price": "20.00" };
var vm3 = new Vue({
    el: '#app21',
    data: {
        counter: 1,
        products: myproduct
    }
})
vm.products.qty = '1';
console.log(vm3);
vm3.$watch('counter', function (nval, oval) {
    alert('计数器值的变化：' + oval + '变为' + nval + '!');
});
