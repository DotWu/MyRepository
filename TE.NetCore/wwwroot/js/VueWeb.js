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
